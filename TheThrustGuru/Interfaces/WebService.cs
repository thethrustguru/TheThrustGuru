using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheThrustGuru.DataModels;

namespace TheThrustGuru.Interfaces
{
    //this contains the endpoints just like retrofit
    interface WebService
    {
        //this is a get request endpoint
        [Get("/items")]
        Task<FoodItemsDataModel> getFoodItems([Header("Authorization")] string authorization);

        [Post("/items")]
        Task postFoodItem([Header("Authorization")] string authorization,[Body] FoodItemsDataModel.FoodItemModel foodItem);

        [Post("/user/login")]
        Task<LoginResultDataModel> loginUser([Body] LoginDataModel loginDataModel);

        [Post("/recipes")]
        Task<RecipeResultDataModel> createRecipe([Header("Authorization")] string authorization, [Body] RecipeDataModel.RecipeData recipeDataModel);

        [Get("/recipes")]
        Task<RecipeDataModel> getAllRecipe([Header("Authorization")] string authorization);
    }
}
