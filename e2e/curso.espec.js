describe('Curso', function() {
    it('deveria criar um curso', async function() {
      
      debugger;
      const nomeDoCursoEsperado = `Curso 44`;
      browser.waitForAngularEnabled(false);
      await browser.get('http://localhost:53695/Curso/Novo');
      element(by.css('[name="Nome"]')).sendKeys(nomeDoCursoEsperado);
      element(by.css('[name="CargaHoraria"]')).sendKeys('10');
      element(by.css('[name="PublicoAlvo"]')).sendKeys('Empregado');
      element(by.css('[name="Valor"]')).sendKeys('1000');
      
      await element(by.css('[name="submit"]')).click();

      browser.debugger();
      
      expect(await element(by.cssContainingText('td', nomeDoCursoEsperado)).isPresent()).toBeTruthy();
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