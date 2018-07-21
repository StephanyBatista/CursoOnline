describe('Curso', function() {
    it('deveria criar um curso', async function() {
      
      const nomeDoCursoEsperado = `Curso ${new Date().getUTCMilliseconds()}`;
      browser.waitForAngularEnabled(false);
      browser.get('http://localhost:53695/Curso/Novo');
      element(by.css('[name="Nome"]')).sendKeys(nomeDoCursoEsperado);
      element(by.css('[name="CargaHoraria"]')).sendKeys('10');
      element(by.css('[name="PublicoAlvo"]')).sendKeys('Empregado');
      element(by.css('[name="Valor"]')).sendKeys('1000');
      
      element(by.buttonText('Salvar')).click()
      browser.sleep(1000);

      expect(browser.getCurrentUrl()).toEqual('http://localhost:53695/Curso');
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