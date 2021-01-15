describe("testAdditionCalculations", () => {
  it('Tests that "3 + 3 = 6" is displayed in resultLabel', () => {
    cy.visit("http://localhost/")
    .get('#additionCalculationsForm').get('#addFirstNumberInput').type('3')
    .get('#additionCalculationsForm').get('#addSecondNumberInput').type('3')
    .get('#additionCalculationsForm').get('#addSubmitButton').click()
    .get('#resultLabel').contains("3 + 3 = 6");

    cy.request('DELETE', 'http://localhost/Home/DeleteCalculations?numberOfTestsRun=1');
  })
})
