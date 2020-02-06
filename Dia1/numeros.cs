using System;

class Imprimir{
	public static int imp(int num){
        if(num == 100){
            Console.WriteLine(num); 
            return 1;
        }else{
            Console.WriteLine(num);
            imp(num++);
        }
    }

	static void Main(){
        int num = 1;
        imp(num);
    }
}