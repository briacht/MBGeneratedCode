# Model Builder Generated Code for Web Apps

Currently, Model Builder only generates code for offline scenarios (e.g. console, desktop) which uses the non-scalable Prediction Engine.

The proposed feature is to detect the app type, and if it is web app or web api, Model Builder will generate different consumption code using the Prediction Engine Pool.

## Proposed Flows

### 1. Web app

User has an existing web project and wants model and consumption to happen in their web app.

 1. User right-clicks on their web app project in Solution Explorer and hits Add > New Item.
 2. In the Add New Item dialog, user selects Machine Learning Model (ML.NET) and names it Sentiment Model.
 3. A new file is added to the project called "SentimentModel.mbconfig" and the Model Builder UI "wizard" opens in a new tool window.
 4. User goes through the steps for training a sentiment analysis model using Model Builder. After training, the model and consumption code are added as code-behind the SentimentModel.config file.
 
 ### 2. Web app via web API

User has an existing web project and wants model and consumption to happen in a web API (which does not yet exist).

 1. User right-clicks on their web app project in Solution Explorer and hits Add > New Item.
 2. In the Add New Item dialog, user selects Machine Learning Model (ML.NET) and names it Sentiment Model.
 3. A new file is added to the project called "SentimentModel.mbconfig" and the Model Builder UI "wizard" opens in a new tool window.
 4. User goes through the steps for training a sentiment analysis model using Model Builder. After training, the model and consumption code are added as code-behind the SentimentModel.config file.
