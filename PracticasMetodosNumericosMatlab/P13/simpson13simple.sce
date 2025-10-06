function R = simpson13simple(a, b)
    R = ((b - a) / 3) * ((fun(a) + 4 * fun((a + b) / 2) + fun(b)) / 2);
endfunction
