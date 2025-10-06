function y = fun(x)
    y = 1./(x+5);
endfunction

x=linspace(-10,0*%pi,100);
y1=fun(x);
y2=daefun(x,1); 
y3=dasfun(x,0.1); 
y4=dcfun(x,0.001);
