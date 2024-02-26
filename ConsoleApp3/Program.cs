using System;
using System.Reflection;

class MyClass
{
    public int field1 = 1;
    protected internal string field2 = "2";
    protected float field3 = 3.3f;
    internal bool field4 = true;
    private double field5 = 1.0;
    static void Main(string[] args)
    {
        Type type = typeof(MyClass);

        TypeInfo typeInfo = type.GetTypeInfo();
        Console.WriteLine("Type Name: " + type.FullName);
        Console.WriteLine("Is Class? " + typeInfo.IsClass);
        Console.WriteLine("Is Public? " + typeInfo.IsPublic);
        Console.WriteLine();

        MemberInfo[] members = type.GetMembers();
        Console.WriteLine("Members:");
        foreach (var member in members)
        {
            Console.WriteLine(member.Name + " - " + member.MemberType);
        }
        Console.WriteLine();

        FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        Console.WriteLine("Fields:");
        foreach (var field in fields)
        {
            Console.WriteLine(field.Name + " - " + field.FieldType);
        }
        Console.WriteLine();

        MethodInfo methodInfo = type.GetMethod("method1", BindingFlags.Static | BindingFlags.Public);
        Console.WriteLine("Method Name: " + methodInfo.Name);
        methodInfo.Invoke(null, null);
        Console.WriteLine();
    }

    public static void method1()
    {
        int a = 1;
        Console.WriteLine(a);
    }

    protected static int method2()
    {
        return 0;
    }

    private static string method3()
    {
        return "";
    }
}