public class Moo<C>
	where C : Moo<C>.Foo
{
	public class Foo
	{ }
}

public class Test : Moo<Test>.Foo
{
}

class X
{
	static void Main ()
	{
		Moo<Test> moo = new Moo<Test> ();
	}
}
