﻿
Partial Class _default
    Inherits System.Web.UI.Page

    Protected Sub PerformCalkButton_Click(sender As Object, e As System.EventArgs) Handles PerformCalkButton.Click
        'specify constant values
        Const INTEREST_CALCS_PER_YEAR As Integer = 12
        Const PAYMENTS_PER_YEAR As Integer = 12

        'create variables to hold the values enter by the users
        Dim P As Decimal = LoanAmount.Text
        Dim r As Decimal = Rate.Text / 100
        Dim t As Decimal = MortgageLength.Text

        Dim ratePerPeriod As Decimal
        ratePerPeriod = r / INTEREST_CALCS_PER_YEAR

        Dim payPeriods As Integer
        payPeriods = t * PAYMENTS_PER_YEAR

        Dim annualRate As Decimal
        annualRate = Math.Exp(INTEREST_CALCS_PER_YEAR * Math.Log(1 + ratePerPeriod)) - 1

        Dim intPerPayment As Decimal
        intPerPayment = (Math.Exp(Math.Log(annualRate + 1) / payPeriods) - 1) * payPeriods

        'now compute the total cost of the loan
        Dim intPerMonth As Decimal = intPerPayment / PAYMENTS_PER_YEAR

        Dim costPerMonth As Decimal
        costPerMonth = P * intPerMonth / (1 - Math.Pow(intPerMonth + 1, -payPeriods))

        'display the results in the results Label Web control 
        Results.Text = "Your Mortgage payment per month is $" & costPerMonth.ToString("#,####.##")

    End Sub
End Class
