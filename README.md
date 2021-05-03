# BDD-Specflow-and-RestSharp

Introduction : It is a BDD framework being developed using C#, specflow and restsharp which is making api calls and compare responses.

Reporting  : We have used extent reporting and implementated all the hooks in a class called Hooks.cs which are being called upon every scenarion/steps to generate reprot after each step.


Folder definitions :
GherkinFeatures : This folder contains all the feature files.

Steps : This folder contains steps definitions corresponsing to each feature file.

JsonResponses : Here we have stored json response for get calls which are being used to compare with API responses.

Common Calls : This are the methods calling each api.

Common : Any common logic being used across application.


Reprot Location : bin\Debug\netcoreapp3.0\Reports\

Report Format : 
![image](https://user-images.githubusercontent.com/42684033/116775524-f9e4f680-aa80-11eb-9419-8e1eb1b66b50.png)

