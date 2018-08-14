
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheThrustGuru.DataModels;
using TheThrustGuru.Interfaces;
using TheThrustGuru.Utils;

namespace TheThrustGuru.Database
{
    class DatabaseOperations
    {
        public static void addData(List<FoodItemsDataModel.FoodItemModel> items)
        {

            //Open database or create if it doesn't exist
            using (var db = new LiteDatabase(@Constants.DB_NAME))
            {
                //get the collection for the table name supplied i.e 'Constants.FOOD_ITEM_TABLE_NAME'
                var FoodItemCollection = db.GetCollection<FoodItemsDataModel.FoodItemModel>(Constants.FOOD_ITEM_TABLE_NAME);

                try
                {
                    //loop through the data to be added to db and insert into the collection
                    foreach(FoodItemsDataModel.FoodItemModel item in items)
                    {
                        FoodItemCollection.EnsureIndex(x => x._id, true);
                        FoodItemCollection.Insert(item);
                    }
                }catch(LiteException ex)
                {
                    //show a messagebox with error message
                    MessageBox.Show(ex.Message,"Error");
                }
               
            } //The using block closes the DB connection automatically when done.  
                    
        }

        public static void addSingleData(FoodItemsDataModel.FoodItemModel foodItem)
        {
            using(var db = new LiteDatabase(@Constants.DB_NAME))
            {
                var FoodItemCollection = db.GetCollection<FoodItemsDataModel.FoodItemModel>(Constants.FOOD_ITEM_TABLE_NAME);

                try
                {
                    FoodItemCollection.EnsureIndex(x => x.name, true);
                    FoodItemCollection.Insert(foodItem);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }
    
        //Since LiteDb returns data as IEnumerable we choose to use that as return type
        public static IEnumerable<FoodItemsDataModel.FoodItemModel> getData()
        {           
            using(var db = new LiteDatabase(Constants.DB_NAME))
            {
                try
                {
                    var FoodItem = db.GetCollection<FoodItemsDataModel.FoodItemModel>(Constants.FOOD_ITEM_TABLE_NAME);

                    //liteDB query to get 100 records in FoodItems Table and sort in ascending order using 'name' 
                    var data = FoodItem.Find(Query.All("name", Query.Ascending), limit: 100);

                    return data;

                }catch(LiteException ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
                             
            }                      
        }

        public static void addRecipe(RecipeDataModel.RecipeData recipe)
        {
            using(var db = new LiteDatabase(@Constants.DB_NAME))
            {
                var RecipeCollection = db.GetCollection<RecipeDataModel.RecipeData>(Constants.RECIPE_TABLE_NAME);
                var FoodItemInRecipeCollection = db.GetCollection<FoodItemsInRecipe>(Constants.FOOD_ITEM_IN_RECIPE_TABLE_NAME);
                var RecipeItemsDataCollection = db.GetCollection<RecipeDataModel.RecipeData.items>(Constants.RECIPE_ITEMS_DATA);

                try
                {
                    RecipeCollection.EnsureIndex(x => x.id, true);
                    RecipeCollection.Insert(recipe);
                    foreach(var data in recipe.itemsData)
                    {
                        data.id = recipe.id;
                        RecipeItemsDataCollection.EnsureIndex(x => x.id);
                        RecipeItemsDataCollection.Insert(data);
                        FoodItemInRecipeCollection.Insert(new FoodItemsInRecipe { id = (FoodItemInRecipeCollection.Count() + 1).ToString(), itemId = data.id, foodItemId = data.foodItems._id });

                    }
                }catch(LiteException ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }                               
            }
        }

        public static void addRecipe(RecipeDataModel recipeDataModel)
        {
            using(var db = new LiteDatabase(@Constants.DB_NAME))
            {
                var RecipeCollection = db.GetCollection<RecipeDataModel.RecipeData>(Constants.RECIPE_TABLE_NAME);
                var FoodItemInRecipeCollection = db.GetCollection<FoodItemsInRecipe>(Constants.FOOD_ITEM_IN_RECIPE_TABLE_NAME);
                var RecipeItemsDataCollection = db.GetCollection<RecipeDataModel.RecipeData.items>(Constants.RECIPE_ITEMS_DATA);

                try
                {
                    foreach (var recipe in recipeDataModel.results)
                    {

                        RecipeCollection.EnsureIndex(x => x.id, true);
                        RecipeCollection.Insert(recipe);
                        if (recipe.itemsData != null && recipe.itemsData.Any())
                            foreach (var data in recipe.itemsData)
                            {
                                data.recipeId = recipe.id;
                                RecipeItemsDataCollection.EnsureIndex(x => x.id);
                                RecipeItemsDataCollection.Insert(data);
                                if (data.foodItems != null)
                                    FoodItemInRecipeCollection.Insert(new FoodItemsInRecipe { id = (FoodItemInRecipeCollection.Count() + 1).ToString(), itemId = data.id, foodItemId = data.foodItems._id });

                            }
                    }
                }
                catch (LiteException ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }            
            }
        }

        public static IEnumerable<RecipeDataModel.RecipeData> getRecipe()
        {
            using(var db = new LiteDatabase(Constants.DB_NAME))
            {
                var RecipeCollection = db.GetCollection<RecipeDataModel.RecipeData>(Constants.RECIPE_TABLE_NAME);
                var FoodItemInRecipeCollection = db.GetCollection<FoodItemsInRecipe>(Constants.FOOD_ITEM_IN_RECIPE_TABLE_NAME);
                var RecipeItemsDataCollection = db.GetCollection<RecipeDataModel.RecipeData.items>(Constants.RECIPE_ITEMS_DATA);
                var FoodItemCollection = db.GetCollection<FoodItemsDataModel.FoodItemModel>(Constants.FOOD_ITEM_TABLE_NAME);


                var recipeData = RecipeCollection.Find(Query.All("recipeName", Query.Ascending), limit: 100);
                if (recipeData == null || !recipeData.Any())
                    return null;
                foreach (var recipe in recipeData)
                {
                    var recipeItems = RecipeItemsDataCollection.Find(Query.EQ("recipeId", recipe.id));
                    if (recipeItems == null || !recipeItems.Any())
                        return null;
                    for (int j = 0; j < recipeItems.Count(); j++)
                    {
                        var data = FoodItemInRecipeCollection.FindOne(Query.EQ("itemId", recipeItems.ElementAt(j).id));
                        if (data == null)
                            continue;
                        var food = FoodItemCollection.FindOne(Query.EQ("_id", data.foodItemId));
                        if (food == null)
                            continue;
                        recipeItems.ElementAt(j).foodItems = food;
                    }
                    recipe.itemsData = recipeItems.ToList();
                }
                return recipeData;


                //try
                //{
                //    var recipeData = RecipeCollection.Find(Query.All("recipeName", Query.Ascending), limit: 100);
                //    if (recipeData == null || !recipeData.Any())
                //        return null;
                //    foreach(var recipe in recipeData)
                //    {
                //        var recipeItems = RecipeItemsDataCollection.Find(Query.EQ("recipeId", recipe.id));
                //        if (recipeItems == null || !recipeItems.Any())
                //            return null;
                //        for (int j = 0; j <= recipeItems.Count(); j++)
                //        {
                //            var data = FoodItemInRecipeCollection.FindOne(Query.EQ("itemId", recipeItems.ElementAt(j).id));
                //            if (data == null)
                //                continue;
                //            var food = FoodItemCollection.FindOne(Query.EQ("_id", data.foodItemId));
                //            if (food == null)
                //                continue;
                //            recipeItems.ElementAt(j).foodItems = food;
                //        }
                //        recipe.itemsData = recipeItems.ToList();
                //    }
                //    return recipeData;
                //}catch(Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //    return null;
                //}
            }
        }

        public static void deleteRecipe(string id)
        {
            using(var db = new LiteDatabase(Constants.DB_NAME))
            {
                var RecipeCollection = db.GetCollection<RecipeDataModel>(Constants.RECIPE_TABLE_NAME);
                var FoodItemInRecipeCollection = db.GetCollection<FoodItemsInRecipe>(Constants.FOOD_ITEM_IN_RECIPE_TABLE_NAME);
            }
        }

        public static void saveToken(LoginResultDataModel loginResult)
        {
            using(var db = new LiteDatabase(Constants.DB_NAME))
            {
                var tokenCollection = db.GetCollection<LoginResultDataModel>(Constants.TOKEN_TABLE_NAME);
                int count = tokenCollection.Count();
                
                
                try
                {
                    if (count == 0)
                    {
                        loginResult.id = (count + 1);
                        tokenCollection.Insert(loginResult);
                    }
                    else
                    {
                        loginResult.id = count;
                        tokenCollection.Update(loginResult);
                    }
                    
                    
                }
                catch(LiteException ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        public static LoginResultDataModel getToken()
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var tokenCollection = db.GetCollection<LoginResultDataModel>(Constants.TOKEN_TABLE_NAME);
                try
                {
                    return tokenCollection.FindById(tokenCollection.Count());

                }
                catch(LiteException ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                    return null;
                }
            }
        }

        public static void saveItems(ItemsDataModel items)
        {
            using(var db = new LiteDatabase(Constants.DB_NAME))
            {
                var itemCollection = db.GetCollection<ItemsDataModel>(Constants.ITEM_TABLE_NAME);
                int count = itemCollection.Count();

                try
                {
                    items.id = (count + 1).ToString();
                    itemCollection.EnsureIndex(x => x.id, true);
                    itemCollection.Insert(items);
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static IEnumerable<ItemsDataModel> getItems()
        {
            using(var db = new LiteDatabase(Constants.DB_NAME))
            {
                var itemCollection = db.GetCollection<ItemsDataModel>(Constants.ITEM_TABLE_NAME);
                try
                {
                    return itemCollection.Find(Query.All("itemName", Query.Ascending), limit: 100);
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public static void AddFood(FoodsDataModel foods)
        {
            using(var db = new LiteDatabase(Constants.DB_NAME))
            {
                var foodsCollection = db.GetCollection<FoodsDataModel>(Constants.FOODS_TABLE_NAME);
                try
                {
                    int index = foodsCollection.Count() + 1;
                    foods.id = index.ToString();
                    foodsCollection.EnsureIndex(x => x.id, true);
                    foodsCollection.Insert(foods);
                }catch(LiteException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static IEnumerable<FoodsDataModel> getFoods()
        {
            using (var db = new LiteDatabase(@Constants.DB_NAME))
            {
                var foodsCollection = db.GetCollection<FoodsDataModel>(Constants.FOODS_TABLE_NAME);
                try
                {
                    return foodsCollection.Find(Query.All("name", Query.Ascending));
                }catch(LiteException ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

    }
}
