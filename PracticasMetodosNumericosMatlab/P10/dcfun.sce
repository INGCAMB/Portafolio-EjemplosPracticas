function y = dcfun(x, d)
        y = (fun(x+d) - fun(x-d))/(2*d);
endfunction
