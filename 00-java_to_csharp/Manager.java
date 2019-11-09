package Angtst;

public class Manager extends Employee
{
	// Attribute um Angestelltendaten zu speichern
  private float weeklysalary;

           		// Konstruktoren
   public Manager(String n)
  {
  	super(n); // gib n an der Parentklassenkonstruktor weiter
        //System.out.println ("bin im Manager Param " + n);
    weeklysalary = 0;
  }

   public Manager()
  {
    weeklysalary = 0;
        //System.out.println ("bin im Managerkonstruktor " );
  }

   public void setweeklysalary (float w)
  {
        weeklysalary = w;
  }


  public float computePay()
  {
    return weeklysalary;
  }

}


