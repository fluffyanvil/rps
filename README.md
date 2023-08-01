Как запустить:
1) Заходим в \src\RockPaperScissors\RockPaperScissors.WebApi
2) В консоли пишем dotnet run
3) Открываем в браузере https://localhost:7052/swagger
4) Вызываем методы контроллера GamesController

Как играть:
1) Создаем игру https://localhost:7052/swagger/index.html#/Games/post_Games_create__userName_
2) Либо подключаем нового игрока https://localhost:7052/swagger/index.html#/Games/put_Games__gameId__join__userName_
3) Либо играем с компьютером https://localhost:7052/swagger/index.html#/Games/post_Games__gameId__playWithCpu
4) Делаем ход https://localhost:7052/swagger/index.html#/Games/post_Games__gameId__user__userId___option_
5) Если играем с компьютером, то делаем шаг 3, если с игроком - ждем, пока он сделает ход
6) Как только все раунды сыграны, можем посмотреть статистику по игре https://localhost:7052/swagger/index.html#/Games/get_Games__gameId__stat
   
