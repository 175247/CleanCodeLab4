describe("testMultiplicationCalculations", () => {
  it('Tests that "3 + 3 = 6" is displayed in resultLabel', () => {
    cy.visit("http://localhost/")
    .get('#multiplicationCalculationsForm').get('#multiplyFirstNumberInput').type('13')
    .get('#multiplicationCalculationsForm').get('#multiplyFecondNumberInput').type('2')
    .get('#multiplicationCalculationsForm').get('#multiplySubmitButton').click()
    .get('#resultLabel').contains("13 * 2 = 26");

    cy.request('DELETE', 'http://localhost/Home/DeleteCalculations?numberOfTestsRun=1');
  })
})
