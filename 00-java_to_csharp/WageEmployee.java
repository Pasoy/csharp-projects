package Angtst;

public class WageEmployee extends Employee
{
	// Attribute um Angestelltendaten zu speichern
  private float wage;
  private float hours;

 		// Konstruktoren

   public WageEmployee(String n)
  {
  	super(n); // gib n an der Parentklassenkonstruktor weiter
        //System.out.println ("bin im WageEmployeekonstruktor Param " + n);
    wage = 0;
    hours = 0;
  }

   public WageEmployee()
  {
    wage = 0;
    hours = 0;
        //System.out.println ("bin im WageEmployeekonstruktor " );
  }

   public void setwage (float w)
  {
        wage = w;
  }
   public void sethours (float h)
  {
        hours = h;
  }

  public float computePay()
  {
    return wage * hours;
  }

}


