class Program
{
	static void Main(string[] args)
	{
		var a1 = new A();
		var a2 = new A();
		var b1 = new B();


		a1.AddB(b1);
		b1.AddA(a1);


		Console.ReadKey();
	}
}

class A
{
	private List<B> bs = new List<B>();

	public void AddB(B b)
	{
		bs.Add(b);
		b.AddA(this);
	}
}

class B
{
	private List<A> asm = new List<A>();

	public void AddA(A a)
	{
		asm.Add(a);
		a.AddB(this);
	}
}
