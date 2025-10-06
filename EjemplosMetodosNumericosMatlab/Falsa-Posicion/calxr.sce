function [y]=calxr(xi, xu, fxi, fxu)
    y = xi - ((xu - xi) / (fxu - fxi)) * fxi;
endfunction
