//controle de valeur de type numérique
Ext.apply(Ext.form.VTypes, {
    numVal: /^[0-9]+$/,
    numMask: /^[0-9]+$/,
    numText: 'La valeur saisie est incorrect.',
    num: function (v) {
        return this.numVal.test(v);
    }
});
//controle de valeur de type alphabétique 
Ext.apply(Ext.form.VTypes, {
    chaineVal: /^[a-zA-Z ]+$/,
    chaineMask: /^[a-zA-Z]+$/,
    chaineText: 'La valeur saisie est incorrect.',
    chaine: function (v) {
        return this.chaineVal.test(v);
    }
});
//controle de valeur alphanumérique
Ext.apply(Ext.form.VTypes, {
    chainenumVal: /^[a-z0-9A-Z]+$/,
    chainenumMask: /^[a-z0-9A-Z]+$/,
    chainenumText: 'La valeur saisie est incorrect.',
    chainenum: function (v) {
        return this.chainenumVal.test(v);
    }
});
