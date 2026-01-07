/// <reference types="cypress"/>
describe("Wpisywanie tekstu w wysukiwarkę", ()=>{
    it("Wpisywanie tekstu", ()=>{
        cy.visit("/");
        cy.get('#search_query_top').type("Przykładowa treść")
        cy.wait(3000)
        cy.get('#search_query_top').clear();
    });
});