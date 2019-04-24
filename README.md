# dotnet_basketball

Instructions for manually populating a clean database.

0)(optional) Make your own free trial account and sports data and update the api key in the service class, so you dont use up all my calls.

1)Log in as admin@fbbm.com

2)/teams/fetch

3)/players/fetch

4)/playerseasonstats/fetch

5)/games/fetch

6)/games/fetchpost  (if its the post season)

7)/playergamestats/fetch
    *This method contains a loop that iterates from a chosen start date to the current day. The start date will default at 03/11/2019, but can be changed inside PlayerGameStatsController.cs. Be careful, you might use up all your api calls.
    
8)/standings/fetch

9)/news/fetch

The database should now be ready to use. 
