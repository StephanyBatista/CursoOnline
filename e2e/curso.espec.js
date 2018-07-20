describe('Curso', function() {
    it('deveria criar um curso', function() {
      
      browser.waitForAngularEnabled(false);
      browser.get('http://localhost:53695/Curso/Novo');
      element(by.css('[name="Nome"]')).sendKeys('Curso 2');
      element(by.css('[name="CargaHoraria"]')).sendKeys('10');
      element(by.css('[name="PublicoAlvo"]')).sendKeys('Empregado');
      element(by.css('[name="Valor"]')).sendKeys('1000');
      
      element(by.css('[name="submit"]')).click();
  
      expect(element(by.cssContainingText('td', 'Curso 2'))).toBeDefined();
    });

    it('deveria validar quando curso está inválido para salvar', function() {
      
      browser.waitForAngularEnabled(false);
      browser.get('http://localhost:53695/Curso/Novo');
      
      element(by.css('[name="submit"]')).click();
  
      expect(element(by.cssContainingText('.toast-error', 'Nome inválido')).isPresent()).toBeTruthy();
      expect(element(by.cssContainingText('.toast-error', 'Carga horária inválida')).isPresent()).toBeTruthy();
      expect(element(by.cssContainingText('.toast-error', 'Valor inválido')).isPresent()).toBeTruthy();
    });
  });