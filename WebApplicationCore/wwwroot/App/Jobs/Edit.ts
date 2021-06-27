namespace JobsEdit
{
    var formulario = new Vue(
        {
            data:
            {
                Formulario: "#FormEdit"
            },
            mounted()
            {
                CreateValidator(this.Formulario);
            }
        });

    formulario.$mount("#AppEdit")
}