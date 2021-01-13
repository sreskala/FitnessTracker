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
| Guid | OwnerId | **Not Displayed** | ----- |
