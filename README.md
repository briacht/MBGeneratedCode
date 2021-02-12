# Model Builder Generated Code for Web Apps

Currently, Model Builder only generates code for offline scenarios (e.g. console, desktop) which uses the non-scalable Prediction Engine.

The proposed feature is to detect the app type, and if it is web app or web api, Model Builder will generate different consumption code using the Prediction Engine Pool.

## Proposed Flows

### 1. Web app

User has an existing web project and wants model and consumption to happen in their web app.

 1. User right-clicks on their web app project in Solution Explorer and hits Add > New Item.
 2. In the Add New Item dialog, user selects Machine Learning Model (ML.NET) and names it SentimentModel.
 3. A new file is added to the project called "SentimentModel.mbconfig" and the Model Builder UI "wizard" opens in a new tool window.
 4. User goes through the steps for training a sentiment analysis (Text classification) model using Model Builder. After training, the model and [consumption code](https://github.com/briacht/MBGeneratedCode/blob/main/webAPI/SentimentModel.consumption.cs) are added as code-behind the SentimentModel.config file.
 5. User is presented with links to docs to see example of how to implement / consume model in their web app. They also have the option to add a sample web app project which utilizes their model.
 
 ### 2. Web app via new web API

User has an existing web project and wants model and consumption to happen in a web API (which does not yet exist).

 1. User right-clicks on their web app project in Solution Explorer and hits Add > New Item.
 2. In the Add New Item dialog, user selects Machine Learning Model (ML.NET) and names it SentimentModel.
 3. A new file is added to the project called "SentimentModel.mbconfig" and the Model Builder UI "wizard" opens in a new tool window.
 4. User goes through the steps for training a sentiment analysis model using Model Builder. After training, the model and consumption code are added as code-behind the SentimentModel.config file as part of the web app project.
 5. After model evaluation, Model Builder asks the user if they would like to generate a new ASP.NET Core Web API for model consumption. If the user chooses this, then the [Web API](https://github.com/briacht/MBGeneratedCode/tree/main/webAPI) is added to their solution, and .mbconfig + code-behind (including the model) is moved to web API project.
 
 ### 3. Web API
 
 User has an existing Web API and wants model and consumption to happen here.
 
 1. User right-clicks on their web API project in Solution Explorer and hits Add > New Item.
 2. In the Add New Item dialog, user selects Machine Learning Model (ML.NET) and names it SentimentModel.
 3. A new file is added to the project called "SentimentModel.mbconfig" and the Model Builder UI "wizard" opens in a new tool window.
 4. User goes through the steps for training a sentiment analysis model using Model Builder. After training, the model and consumption code are added as code-behind the SentimentModel.config file as part of the web API project.
 5. User is presented with links to docs to see example of how to implement / consume model in their web API. They also have the option to add a sample web API project which utilizes their model.
