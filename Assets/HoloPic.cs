using UnityEngine;


public enum HoloState
{
    BASE,
    STRIPES,
    BOTH,
    NEITHER
}
public class HoloPic
{
    private readonly Texture2D _original;
    private readonly Texture2D _overlay;
    private readonly Color _color;
    private HoloState _state;

    public HoloPic(Texture2D original, Color color, float fuzz)
    {
        this._original = original;
        this._color = color;
        this._state = HoloState.BOTH;
        //stripe generation algo goes here
    }


    public Texture2D GetOriginal()
    {
        return this._original;
    }
    public Texture2D GetOverlay()
    {
        return this._overlay;
    }
    public Color GetColor()
    {
        return this._color;
    }
    public HoloState GetState()
    {
        return this._state;
    }
    public void SetState(HoloState state)
    {
        this._state = state;
    }
    public HoloState CycleState()
    {
        this._state = (HoloState)((((int)this._state) + 1) % 5);
        return this._state;
    }
}
