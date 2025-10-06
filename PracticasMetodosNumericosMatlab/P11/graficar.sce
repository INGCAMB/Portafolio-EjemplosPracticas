x=linspace(0, 6*%pi, 100); //PONER INDIVIDUAL A CADA UNO
y1=fun(x);
y2=pdfun(x, d);
y3=sdfun(x, d);

plot(x, y1, '-black', x, y2, '-r', x, y3, '-g')
title('Medina Beltran Carlos Alberto')
xlabel('eje x')
ylabel('eje y')
legend('función','1ra derivada','2da derivada')
