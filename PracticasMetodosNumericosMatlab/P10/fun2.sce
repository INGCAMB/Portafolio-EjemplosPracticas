function y = fun(x)
    y = %e^(-x+1);
endfunction

x=linspace(1,10,100);
y1=fun(x);
y2=daefun(x,0.1); 
y3=dasfun(x,0.05); 
y4=dcfun(x,0.01);
