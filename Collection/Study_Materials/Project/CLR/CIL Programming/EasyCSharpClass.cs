public class EasyCSharpClass
{
private int m_AMemberVariable;
public void AMethod()
{
int x = 0;
x++;
x += CalledMethod();
m_AMemberVariable = 0;
}
private int CalledMethod()
{
return m_AMemberVariable;
}
}