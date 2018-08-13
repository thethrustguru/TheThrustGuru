
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
                }catch(Exception ex)
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
                var FoodItem = db.GetCollection<FoodItemsDataModel.FoodItemModel>(Constants.FOOD_ITEM_TABLE_NAME);

                //liteDB query to get 100 records in FoodItems Table and sort in ascending order using 'name' 
                var data = FoodItem.Find(Query.All("name", Query.Ascending), limit: 100);

                return data;             
            }                      
        }

        public static void addRecipe(RecipeDataModel.RecipeData recipe)
        {
            using(var db = new LiteDatabase(@Constants.DB_NAME))
            {
                var RecipeCollection = db.GetCollection<RecipeDataModel>(Constants.RECIPE_TABLE_NAME);
                var FoodItemInRecipeCollection = db.GetCollection<FoodItemsInRecipe>(Constants.FOOD_ITEM_IN_RECIPE_TABLE_NAME);
                
                //try
                //{                   
                //    //get total count of collection incremet and set as recipe id
                //    //recipe.id = (RecipeCollection.Count() + 1).ToString();
                //    RecipeCollection.EnsureIndex(x => x.id, true);
                //    RecipeCollection.Insert(recipe);
                //foreach (var data in recipe.foodItems)
                //{
                //    FoodItemInRecipeCollection.Insert(new FoodItemsInRecipe {id = (FoodItemInRecipeCollection.Count() + 1).ToString(),
                //        foodItemId = data._id, recipeId = recipe.id });
                //}

                //}catch(Exception ex)
                //{
                //    MessageBox.Show(ex.Message, "Error");
                //}
            }
        }

        public static IEnumerable<RecipeDataModel.RecipeData> getRecipe()
        {
            using(var db = new LiteDatabase(Constants.DB_NAME))
            {
                var RecipeCollection = db.GetCollection<RecipeDataModel>(Constants.RECIPE_TABLE_NAME);
                var FoodItemInRecipeCollection = db.GetCollection<FoodItemsInRecipe>(Constants.FOOD_ITEM_IN_RECIPE_TABLE_NAME);
                try
                {
                    var recipeData = RecipeCollection.Find(Query.All("recipeName", Query.Ascending), limit: 100);
                    var recipeFoodItems = FoodItemInRecipeCollection.Find(Query.All(), limit: 100);

                   return null;
                }catch(Exception ex)
                {
                    return null;
                }
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
                catch(Exception ex)
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
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                    return null;
                }
            }
        }

    }
}
