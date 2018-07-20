describe('angularjs homepage todo list', function() {
    it('should add a todo', function() {
      browser.waitForAngularEnabled(false);
      browser.get('http://localhost:53695/');
  
      expect(browser.getTitle()).toEqual('Home Page - CursoOnline.Web');
    });
  });