Как запустить:
1) Заходим в \src\RockPaperScissors\RockPaperScissors.WebApi
2) В консоли пишем dotnet run
3) Открываем в браузере https://localhost:7052/swagger
4) Вызываем методы контроллера GamesController

Как играть:
1) Создаем игру https://localhost:7052/swagger/index.html#/Games/post_Games_create__userName_
2.1) Либо подключаем нового игрока https://localhost:7052/swagger/index.html#/Games/put_Games__gameId__join__userName_
2.2) Либо играем с компьютером https://localhost:7052/swagger/index.html#/Games/post_Games__gameId__playWithCpu
3) Делаем ход https://localhost:7052/swagger/index.html#/Games/post_Games__gameId__user__userId___option_
4) Если играем с компьютером, то делаем шаг 3, если с игроком - ждем, пока он сделает ход
5) Как только все раунды сыграны, можем посмотреть статистику по игре https://localhost:7052/swagger/index.html#/Games/get_Games__gameId__stat
   
