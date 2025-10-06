function y = tdfun(x, d)
    y = (fun(x + 3*d) - 3*fun(x + 2*d) + 3*fun(x + d) - fun(x)) / d^3
endfunction
