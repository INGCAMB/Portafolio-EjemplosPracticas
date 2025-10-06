function y = sdfun(x, d)
    y = (fun(x + 2*d) - 2*fun(x + d) + fun(x)) / d^2;
endfunction
