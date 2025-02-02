package com.gudu.morning.widget;

import android.content.Context;
import android.content.res.TypedArray;
import android.graphics.drawable.Drawable;
import android.util.AttributeSet;
import android.view.MotionEvent;

import com.gudu.morning.app.ThemeManager;
import com.gudu.morning.drawable.RippleDrawable;
import com.gudu.morning.util.ViewUtil;

public class Button extends android.widget.Button implements ThemeManager.OnThemeChangedListener{

	private RippleManager mRippleManager;

    protected int mStyleId;
    protected int mCurrentStyle = ThemeManager.THEME_UNDEFINED;

    public Button(Context context) {
        super(context);

        init(context, null, 0, 0);
    }

    public Button(Context context, AttributeSet attrs) {
        super(context, attrs);

        init(context, attrs, 0, 0);
    }

	public Button(Context context, AttributeSet attrs, int defStyleAttr) {
		super(context, attrs, defStyleAttr);
		
		init(context, attrs, defStyleAttr, 0);
	}

    public Button(Context context, AttributeSet attrs, int defStyleAttr, int defStyleRes) {
        super(context, attrs, defStyleAttr);

        init(context, attrs, defStyleAttr, defStyleRes);
    }

	private void init(Context context, AttributeSet attrs, int defStyleAttr, int defStyleRes){
        ViewUtil.applyFont(this, attrs, defStyleAttr, defStyleRes);
        applyStyle(context, attrs, defStyleAttr, defStyleRes);
        mStyleId = ThemeManager.getStyleId(context, attrs, defStyleAttr, defStyleRes);
	}

    public void applyStyle(int resId){
        ViewUtil.applyStyle(this, resId);
        applyStyle(getContext(), null, 0, resId);
    }

    protected void applyStyle(Context context, AttributeSet attrs, int defStyleAttr, int defStyleRes){
        getRippleManager().onCreate(this, context, attrs, defStyleAttr, defStyleRes);
    }

    @Override
    public void onThemeChanged(ThemeManager.OnThemeChangedEvent event) {
        int style = ThemeManager.getInstance().getCurrentStyle(mStyleId);
        if(mCurrentStyle != style){
            mCurrentStyle = style;
            applyStyle(mCurrentStyle);
        }
    }

    @Override
    protected void onAttachedToWindow() {
        super.onAttachedToWindow();
        if(mStyleId != 0) {
            ThemeManager.getInstance().registerOnThemeChangedListener(this);
            onThemeChanged(null);
        }
    }

    @Override
    protected void onDetachedFromWindow() {
        super.onDetachedFromWindow();
        mRippleManager.cancelRipple(this);
        if(mStyleId != 0)
            ThemeManager.getInstance().unregisterOnThemeChangedListener(this);
    }

    @Override
    public void setBackgroundDrawable(Drawable drawable) {
        Drawable background = getBackground();
        if(background instanceof RippleDrawable && !(drawable instanceof RippleDrawable))
            ((RippleDrawable) background).setBackgroundDrawable(drawable);
        else
            super.setBackgroundDrawable(drawable);
    }

    protected RippleManager getRippleManager(){
        if(mRippleManager == null){
            synchronized (RippleManager.class){
                if(mRippleManager == null)
                    mRippleManager = new RippleManager();
            }
        }

        return mRippleManager;
    }

    @Override
	public void setOnClickListener(OnClickListener l) {
        RippleManager rippleManager = getRippleManager();
        if (l == rippleManager)
            super.setOnClickListener(l);
        else {
            rippleManager.setOnClickListener(l);
            setOnClickListener(rippleManager);
        }
	}
	
	@Override
    public boolean onTouchEvent( MotionEvent event) {
		boolean result = super.onTouchEvent(event);
		return  getRippleManager().onTouchEvent(event) || result;
	}

}
