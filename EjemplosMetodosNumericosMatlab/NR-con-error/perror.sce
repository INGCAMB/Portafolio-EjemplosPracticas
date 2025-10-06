function [y]=perror(xactual, xanterior)
    y = ((xactual - xanterior) / xactual) * 100;
endfunction
