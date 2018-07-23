import { Selector } from 'testcafe';

fixture('Acessando servidor')
    .page('localhost:3000');

test('acessando', async t => {
    
    await t.expect(Selector('title').innerText).eql('Home Page - CursoOnline.Web');
});

//http://devexpress.github.io/testcafe/documentation/test-api/selecting-page-elements/selectors/functional-style-selectors.html