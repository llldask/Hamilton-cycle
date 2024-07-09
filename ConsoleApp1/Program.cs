using ZiRgr;

//var a=ZeroNowledge.fileToArray();

//ZeroNowledge.Print(a);
var A = new Alice();
Console.WriteLine();
A.matrixForBob();
var B=new Bob();
var answ = A.Answer(2);
//answ.isoGraph[0, 0] = 5;
//answ.cellGraphList[4].value = 4;
B.check(answ);