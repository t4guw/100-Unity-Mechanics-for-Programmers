using UnityEngine.UI;
public class BetterScrollRect : ScrollRect
{

    override protected void LateUpdate()
    {
        base.LateUpdate();
        if (this.verticalScrollbar)
        {
            this.verticalScrollbar.size = 0.5f;
        }
        if (this.horizontalScrollbar)
        {
            this.horizontalScrollbar.size = 0.5f;
        }
    }

    override public void Rebuild(CanvasUpdate executing)
    {
        base.Rebuild(executing);
        if (this.verticalScrollbar)
        {
            this.verticalScrollbar.size = 0.5f;
        }
        if (this.horizontalScrollbar)
        {
            this.horizontalScrollbar.size = 0.5f;
        }
    }
}