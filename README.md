# dotnet_basketball

The database populates from /Services/Timers/TimerFetch.cs, the fetch method is set to my prod env where I only pull the data I need. If you are starting with an empty database, uncomment the api calls you need and do not change their order. Afterwards, the calls I have uncommented here are all you need to maintain the database. Please note the following considerations:

0) Make your own free trial account and sports data and update the api key in the service class, so you dont use up all my calls. You can change the subscription key in the /Services/DataService.cs constructor. 

1) Admin account is admin@fbbm.com, password is Password12#

2) /Services/PlayerGameStatsService/FetchAsync() contains a start date for which all game logs after will be selected. Be careful with this date as it is easy to use up all of your api calls on the free trial account. If you are starting with an empty database I would start with March 15th, 2019.
