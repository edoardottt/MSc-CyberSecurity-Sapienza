
/*
  This assignment illustrates how specifications such as invariants and
  preconditions written in a formal language can help in removing
  errors in code.

  The assignment concerns a class "Person" that is used for Persons.

 */
class Person {



 /* isFemale is true iff the person is female */
 //@ invariant (this.isFemale == true) ==> (this.isMale == false);
 //@ invariant (this.isFemale == false) ==> (this.isMale == true);
 boolean isFemale;

 /* isMale is true iff the person is male */
 //@ invariant (this.isMale == true) ==> (this.isFemale == false);
 //@ invariant (this.isMale == false) ==> (this.isFemale == true);
 boolean isMale;



 /*@ nullable @*/ Person father, mother; // These fields won't really be used

 /* Age in years */
 int age;

 boolean isMarried;

 /* Reference to spouse if person is married, null otherwise */
 //@ invariant (this.isMarried == false) ==> this.spouse == null;
 //@ invariant (this.spouse == null) ==> this.isMarried == false;
 //@ invariant (this.isMarried == true) ==> this.spouse != null;
 //@ invariant (this.spouse != null) ==> this.isMarried == true;
 //@ invariant (this.spouse != null) ==> (this.isFemale != spouse.isFemale);
 //@ invariant (this.spouse != null) ==> (this.isMale != spouse.isMale);
 //@ invariant (this.spouse != null) ==> (this.spouse.spouse == this);
 //@ invariant (this.spouse != null) ==> (this.age >= 18);
 //@ invariant (this.spouse != null) ==> (this.spouse.age >= 18);
 //@ invariant (this.isMarried == true) ==> (this.age >= 18);
 //@ invariant (this.isMarried == true) ==> (this.spouse.age >= 18);
 /*@ nullable @*/ Person spouse;

 /* welfare subsidy */
 //@ invariant (this.age <= 65 && this.isMarried == false) ==> (this.state_subsidy == 500);
 //@ invariant (this.age <= 65 && this.isMarried == true) ==> (this.state_subsidy == 350);
 //@ invariant (this.age > 65 && this.isMarried == false) ==> (this.state_subsidy == 600);
 //@ invariant (this.age > 65 && this.isMarried == true) ==> (this.state_subsidy == 420);
 int state_subsidy;


 /* CONSTRUCTOR */

 Person(boolean s, Person ma, Person pa) {
   age = 0; 
   isMarried = false;
   this.isMale = s;
   this.isFemale = !s;
   mother = ma;
   father = pa;
   spouse = null;
   int DEFAULT_SUBSIDY = 500;
   state_subsidy = DEFAULT_SUBSIDY;
  
 }

 /* METHODS */

 /* Marry to new_spouse */
 //@ requires new_spouse != null;
 //@ requires this.spouse == null;
 //@ requires this.isMarried == false;
 //@ requires new_spouse.isMarried == false;
 //@ requires new_spouse.spouse == null;
 //@ requires this.isMale != new_spouse.isMale;
 //@ requires this.isFemale != new_spouse.isFemale;
 //@ requires new_spouse.age >= 18;
 //@ requires this.age >= 18;
 //@ ensures new_spouse.isMarried == true;
 //@ ensures this.spouse == new_spouse;
 //@ ensures new_spouse.spouse == this;
 void marry(Person new_spouse) {
  new_spouse.isMarried = true;
  new_spouse.spouse = this;
  spouse = new_spouse;
  isMarried = true;
  if (age <= 65) state_subsidy = 350;
  if (age > 65) state_subsidy = 420;
  if (spouse.age <= 65) spouse.state_subsidy = 350;
  if (spouse.age > 65) spouse.state_subsidy = 420;
 }

 /* Divorce from current spouse */
 //@ requires this.spouse != null;
 //@ requires this.isMarried == true;
 //@ requires this.spouse.spouse != null;
 //@ requires this.spouse.isMarried == true;
 void divorce() {
  if (spouse.age <= 65) spouse.state_subsidy = 500;
  if (spouse.age > 65) spouse.state_subsidy = 600;
  spouse.isMarried = false;
  spouse.spouse = null;
  spouse = null;
  isMarried = false;
  if (age <= 65) state_subsidy = 500;
  if (age > 65) state_subsidy = 600;
 }



 /* Person has a birthday and the age increases by one */
 //@ requires age < 200;
 void haveBirthday() {
  age = age + 1;
  if (age > 65 && isMarried) state_subsidy = 420;
  if (age > 65 && !isMarried) state_subsidy = 600;
 }

}