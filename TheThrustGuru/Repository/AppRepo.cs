using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheThrustGuru.DataModels;
using TheThrustGuru.Interfaces;

namespace TheThrustGuru.Repository
{
    class AppRepo
    {
        private const string BASE_URL = "https://thethrustguru.herokuapp.com";
        private WebService server;

        public AppRepo()
        {
            //initialize the webservice class with RestService
            server = RestService.For<WebService>(BASE_URL);
        }

        //A synchronous task to get data from the server. Objects should call this task asynchronously
        public Task<FoodItemsDataModel> getFoodItemsFromServer(String auth)
        {
            return  server.getFoodItems(auth);                            
        }

        public Task postFoodItemToServer(string auth,FoodItemsDataModel.FoodItemModel foodItem)
        {
            return server.postFoodItem(auth,foodItem);
        }

        public Task<LoginResultDataModel> loginUser(LoginDataModel loginDataModel)
        {
            return server.loginUser(loginDataModel);
        }

        public Task<RecipeResultDataModel> createRecipe(string auth, RecipeDataModel.RecipeData recipeDataModel)
        {
            return server.createRecipe(auth, recipeDataModel);
        }

        public Task<RecipeDataModel> getAllRecipe(string auth)
        {
            return server.getAllRecipe(auth);
        }
    }
}
