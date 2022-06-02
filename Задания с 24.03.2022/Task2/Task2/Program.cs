using Game;

var eventLoop = new EventLoop();
var game = new Game.Game("../../../map.txt");
game.DrawMap();

eventLoop.leftHandler += game.OnLeft!;
eventLoop.rightHandler += game.OnRight!;
eventLoop.upHandler += game.OnUp!;
eventLoop.downHandler += game.OnDown!;

eventLoop.Run();