# dotnet_basketball
The database will automatically populate upon startup and each day on a timer. Please note the following considerations:

0) Make your own free trial account and sports data and update the api key in the service class, so you dont use up all my calls. You can change the subscription key in the /Services/DataService constructor. 

1) Admin account is admin@fbbm.com, password is Password12#

2) /Services/PlayerGameStatsService/FetchAsync() contains a start date for which all game logs after will be selected. Be careful with this date as it is easy to use up all of your api calls on the free trial account. 
