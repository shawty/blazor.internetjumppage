window.blazorUtilsFunctions = {

  setFocus: function (elementId) {
    let element = document.getElementById(elementId);
    if (undefined === element) return null;
    if (null === element) return null;
    element.focus();
    return null;
  },

  message: function (message) {
    alert(message);
  },

  isFormValid: function (formRef) {
    return formRef.checkValidity();
  }

};
