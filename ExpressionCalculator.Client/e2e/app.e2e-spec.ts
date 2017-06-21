import { AngularCliTestPage } from './app.po';

describe('angular-cli-test App', () => {
  let page: AngularCliTestPage;

  beforeEach(() => {
    page = new AngularCliTestPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!!');
  });
});
