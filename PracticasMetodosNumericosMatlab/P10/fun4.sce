function y = fun(x)
    y = %e^x .* sin (x);
endfunction

x=linspace(0.1,6*%pi,100);
y1=fun(x);
y2=daefun(x,1); 
y3=dasfun(x,0.1); 
y4=dcfun(x,0.001);
