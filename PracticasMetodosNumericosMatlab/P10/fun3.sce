function y = fun(x)
    y = %e^x .* sin (x);
endfunction

x=linspace(1,6*%pi,100);
y1=fun(x);
y2=daefun(x,0.3); 
y3=dasfun(x,0.08); 
y4=dcfun(x,0.001);
