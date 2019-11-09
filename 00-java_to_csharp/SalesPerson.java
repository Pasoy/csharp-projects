package Angtst;

public class SalesPerson extends WageEmployee
{
	// zusätzliche Attribute um Verkaufsdaten zu speichern
  private double commission;
  private double salesmade;

 		// Konstruktoren
   public SalesPerson(String n)
  {
  	super(n); // gib n an der Parentklassenkonstruktor weiter
      //System.out.println ("bin im SalesPersonkonstruktor Param " + n);
    commission =0;
    salesmade = 0;
  }
   public SalesPerson()
  {
    commission =0;
    salesmade = 0;
      //System.out.println ("bin im SalesPersonkonstruktor Param " + n);
  }

  public void setcommission (double c)
  {
        commission = c;
  }
   public void setsalesmade (double s)
  {
        salesmade = s;
  }

  public String toString ()
  {
        return getname() + " ist ein Salesp";
  }

  public float computePay()
  {
    return (float) (commission * salesmade + super.computePay());
  }
}


