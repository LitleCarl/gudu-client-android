package com.zaocan84.zeng;

import android.content.Context;
import android.content.res.TypedArray;
import android.graphics.Color;
import android.graphics.drawable.Drawable;
import android.util.AttributeSet;
import android.widget.RelativeLayout;

import com.zaocan84.zeng.R;
import com.zaocan84.zeng.drawable.BorderDrawable;

public class BorderRelativeLayout extends RelativeLayout {

	private BorderDrawable borderDrawable;
	
	public BorderRelativeLayout(Context context, AttributeSet attrs) {
		super(context, attrs);
		
		if(borderDrawable == null)
			borderDrawable = new BorderDrawable();
		
		if(attrs != null)
		{
			TypedArray a = getResources().obtainAttributes(attrs, R.styleable.BorderRelativeLayout);
			
			int width, color;
			
			width = (int) a.getDimension(R.styleable.BorderRelativeLayout_leftBorderWidth, 0);
			color = a.getColor(R.styleable.BorderRelativeLayout_leftBorderColor, Color.BLACK);
			borderDrawable.setLeftBorder(width, color);
			
			width = (int) a.getDimension(R.styleable.BorderRelativeLayout_topBorderWidth, 0);
			color = a.getColor(R.styleable.BorderRelativeLayout_topBorderColor, Color.BLACK);
			borderDrawable.setTopBorder(width, color);
			
			width = (int) a.getDimension(R.styleable.BorderRelativeLayout_rightBorderWidth, 0);
			color = a.getColor(R.styleable.BorderRelativeLayout_rightBorderColor, Color.BLACK);
			borderDrawable.setRightBorder(width, color);
			
			width = (int) a.getDimension(R.styleable.BorderRelativeLayout_bottomBorderWidth, 0);
			color = a.getColor(R.styleable.BorderRelativeLayout_bottomBorderColor, Color.BLACK);
			borderDrawable.setBottomBorder(width, color);
		}
		
		if(getBackground() != null)
		{
			borderDrawable.setBackground(borderDrawable);
		}
		
		setBackgroundDrawable(borderDrawable);
	}
	
	@Override
	public void setBackgroundDrawable(Drawable d) {
		if(d == borderDrawable)
			super.setBackgroundDrawable(d);
		else
		{
			if(borderDrawable == null)
				borderDrawable = new BorderDrawable();
			borderDrawable.setBackground(d);
		}
	}
	
	public BorderRelativeLayout(Context context) {
		this(context, null);
	}

	
	
}
