function R = simpson13simple(a, b)
    R = ((b - a) / 8) * ((fun(a) + 3 * fun((2*a + b) / 3) + fun(b)) / 2);
endfunction
