namespace LightHTML.Visitor
{
    public interface ILightNodeVisitor
    {
        void VisitElement(LightElementNode element);
        void VisitText(LightTextNode text);
    }
}
