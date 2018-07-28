import { Selector } from 'testcafe';

fixture('Acessando servidor')
    .page('localhost:3000');

test('acessando', async t => {
    
    await t.expect(Selector('title').innerText).eql('Home Page - CursoOnline.Web');
});

