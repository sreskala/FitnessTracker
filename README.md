# Health Warrior - A Fitness Tracking Application

<p align="center">
  <img src="https://github.com/sreskala/FitnessTracker/blob/master/FitnessTracker/Content/Image/health-warrior-logo.png?raw=true" alt="health warrior logo" />
</p>

Links:
-[Website Link](https://health-warrior.azurewebsites.net/ "Health Warrior Homepage")
-[Trello Board](https://trello.com/b/CXD2SpvN/fitness-tracking-app)

Technology/Tools used: **C#, ASP.NET MVC, HTML, CSS, JavaScript, Azure**

## What is Health Warrior
Health Warrior was created in order to bring both facets of a healthy lifestyle together: Nutrition and Exercise. Our application looks to bridge the gap that most other tracking applications fail to meet. How? Health Warrior lets you fully customize every aspect of both your meal plans and workout plans.


Within each meal plan is the ability to add several meals to it, helping you separate a certain plan from another. Then within each meal you are able to create and add specific food-items to help organize your plan, with the option of customizing every aspect of it from quantity to calories to the food name (that might not even show up on other tracking apps).


Each workout plan lets you tailor its containing workouts so you can go as hard (or light if it's a rest day) as you want. The workouts let you add individual exercises to them to plan as best as possible for your routine. The exercises, just like the food-items, are fully customizable to best fit what you're looking for.

## Tables and Properties
---------

### User Table
The first table is the ApplicationUser table which is autogenerated by the framework and came with properties such as ID, Email, UserName, and many others not implemented in this project. I created additional properties for each user which were FirstName, LastName, Height, and Weight. The table below describes all the properties used.

| Property Name | Type | Display Name | Example |
|---------------|------|--------------|---------|
| ID | Guid | **Not Displayed** |  --- |
| Email | String | Email | fitness@healthwarrior.com |
| UserName | String | _same as email_ | fitness@healthwarrior.com |
| FirstName | String | First Name | Sam |
| LastName | String | Last Name | Reskala |
| Height | Integer | Height in Inches | 70 |
| Weight | Integer | Weight in Pounds | 220 |

One of the issues I ran into was not being able to access these custom user properties in my Views section. What I did was create claims for each one, create extension methods for each claim which then I was able to call on from the View I wanted using the Identity model. For example, for accessing the height of each user this was what the code looked like:

In IdentityModels:
```C#
public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("Height", this.Height.ToString()));
            return userIdentity;
        }
        
        public int Height {get; set;}
```
In an Extensions file:
```C#
public static class IdentityExtension
    {
        /// <summary>
        /// Gets the current users height.
        /// </summary>
        /// <returns>Height as a string or empty string if null</returns>
        public static string GetUserHeight(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("Height");
            return (claim != null) ? claim.Value : string.Empty;
        }
```
Then in my view:
```C#
@using Microsoft.Asp.Identity
@using MyProjectName.Extensions

<h3>User.Identity.GetUserHeight()</h3>
```

### Meal Plan Table
The second table was a simple meal plan table which would allow a user to add meals to it. It's properties are:

| Property Name | Type | Display Name | Example |
|---------------|------|--------------|---------|
| MealPlanId | Integer | Meal Plan # | 7 |
| Title | String | Title | Keto Diet Plan |
| DateCreatedUtc | DateTimeOffset | Date Created | 1/1/2021 4:00PM |
| DateModifiedUtc | DateTimeOffset? | Date Modified | 1/12/2021 3:50PM |
| Length | Integer? | Length in Weeks | 12 |
| OwnerId | Guid | **Not Displayed** | ----- |


## Meal Table
A meal plan can consist of one or several meals under it. Each meal has the following properties:

| Property Name | Type | Display Name | Example |
|---------------|------|--------------|---------|
| MealId | Integer | Meal # | 12 |
| Title | String | Title | Breakfast |
| OwnerId | Guid | **Not Displayed** | ---- |
| MealPlanId (Foreign Key) | Integer | Tied to Meal Plan # | 7 |
| MealPlan | Virtual MealPlan | **Not Displayed** | _used for relational tables_ |

The foreign key of MealPlanId helps identify which MealPlan this specific meal is tied to, so that the relational table can link them up.


## Food Item Table
A meal can then be made up of several food items to make a full meal. Each food item has the following properties:

| Property Name | Type | Display Name | Example |
|---------------|------|--------------|---------|
| FoodItemId | Integer | Food Item # | 3 |
| Name | String | Name | Eggs Overeasy |
| Quantity | Integer | Quantity | 2 |
| Calories | Integer | Calories | 350 |
| OwnerId | Guid | **Not Displayed** | ---- |
| MealId(Foreign Key) | Integer | Tied to Meal # | 12 |
| Meal | Virtual Meal | **Not Displayed** | _used for relational tables_ |

The foreign key of MealId helps identify which Meal this specific food item is tied to so that the relational table can link them up.


## Workout Plan Table
This table allows a user to add Workout plans. Its properties are:

| Property Name | Type | Display Name | Example |
|---------------|------|--------------|---------|
| WorkoutPlanId | Integer | Workout Plan # | 1 |
| Title | String | Title | Shredding Workout Plan |
| DateCreatedUtc | DateTimeOffset | Date Created | 1/1/2021 4:00PM |
| DateModifiedUtc | DateTimeOffset? | Date Modified | 1/12/2021 3:50PM |
| OwnerId | Guid | **Not Displayed** | ----- |


## Workout Table
Each workout plan is composed of workouts. Each workout has the following properties:

| Property Name | Type | Display Name | Example |
|---------------|------|--------------|---------|
| WorkoutId | Integer | Workout # | 5 |
| Title | String | Title | Morning Routine |
| OwnerId | Guid | **Not Displayed** | ---- |
| WorkoutPlanId (Foreign Key) | Integer | Tied to Workout Plan # | 1 |
| WorkoutPlan | Virtual WorkoutPlan | **Not Displayed** | _used for relational tables_ |


## Exercise Table
Each workout is then made up of several exercises. Each exercise has the following properties: 

| Property Name | Type | Display Name | Example |
|---------------|------|--------------|---------|
| ExerciseId | Integer | Exercise # | 5 |
| Name | String | Name | Preacher Curl |
| Description | String | Descripition | _long exercise description goes here..._ |
| Repetition | Integer | Reps | 10 |
| Sets | Integer | Sets | 5 |
| Length | Integer | Length in Minutes | 15 |
| Type | WorkoutType (enum) | Type of Workout | Weights |
| Muscle | MuscleGroup (enum) | Muscle | Biceps |
| OwnerId | Guid | **Not Displayed** | ---- |
| WorkoutId (Foreign Key) | Integer | Tied to Workout # | 5 |
| Workout | Virtual Workout | **Not Displayed** | _used for relational tables_ |


## Goal Table
This table consists of goals a user has and contains the following properties: 

| Property Name | Type | Display Name | Example |
|---------------|------|--------------|---------|
| GoalId | Integer | Goal # | 2 |
| Title | String | Title | Workout 5 Times a Week |
| Description | String | Description | _Lengthy goal description_ |
| DateCreatedUtc | DateTimeOffset | Date Created | 1/1/2021 4:00PM |
| DateModifiedUtc | DateTimeOffset? | Date Modified | 1/12/2021 3:50PM |
| Completed | Boolean | Completed | true |
| OwnerId | Guid | **Not Displayed** | ---- |


There are a couple of relational tables that tie all the data together but they just consist of objects from what they're tying together in order to used them within the application context.


-------------

## How To Use
