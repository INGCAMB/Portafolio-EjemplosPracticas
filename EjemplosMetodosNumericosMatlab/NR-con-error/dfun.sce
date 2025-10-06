function [y]=dfun(x)
    y = -((30 * x * exp(-(3 / 20) * x) + 200 * exp(-(3 / 20) * x)) / x^2);
endfunction
