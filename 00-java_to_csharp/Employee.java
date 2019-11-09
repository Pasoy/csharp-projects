package Angtst;

public class Employee
{
	// Attribute um Angestelltendaten zu speichern
  private String name;


 		// Konstruktoren
  public Employee()
  {
    	name = "Hugo";
         // System.out.println ("bin im Employeekonstruktor");
  }
   public Employee(String n)
  {
  	name = n;
        //System.out.println ("bin im Employeekonstruktor Param " + n);
  }
  

   protected String getname ()
  {
        return name;
  }


     public String toString ()
  {
        return name;
  }

   public float computePay()
  {
    return 0;
  }  
}


